using LiStream.Displayables;
using LiStream.Displayables.Interfaces;

public class DisplayableDataRetriever : IDisplayableDataRetriever
{
        private readonly Dictionary<MenuOption, Func<IList<IDisplayable>>> _displayAllMethodMap;
        private readonly Dictionary<MenuOption, Func<IDisplayable, IList<IDisplayable>>> _displayableMethodsMap;
        private readonly Dictionary<MenuOption, Func<IDisplayable, IList<IDisplayable>>> _displayableSimilarMethodMap; 

        public DisplayableDataRetriever(
            Dictionary<MenuOption, Func<IList<IDisplayable>>> displayAllMethodMap,
            Dictionary<MenuOption, Func<IDisplayable, IList<IDisplayable>>> displayableMethodsMap,
            Dictionary<MenuOption, Func<IDisplayable, IList<IDisplayable>>> displayableSimilarMethodMap)
        {
            _displayAllMethodMap = displayAllMethodMap;
            _displayableMethodsMap = displayableMethodsMap;
            _displayableSimilarMethodMap = displayableSimilarMethodMap;
        }

    public IList<IDisplayable> GetDisplayables(MenuOption option)
    {
        if (_displayAllMethodMap.TryGetValue(option, out var method))
        {
            return method.Invoke();
        }
        return new List<IDisplayable>();
    }

    public IList<IDisplayable> GetDisplayables(MenuOption option, IDisplayable displayable)
    {
        if (_displayableMethodsMap.TryGetValue(option, out var method))
        {
            return method.Invoke(displayable);
        }
        
        return new List<IDisplayable>();
    }

    public IList<IDisplayable> GetSimilar(MenuOption option, IDisplayable displayable)
    {
        if (_displayableSimilarMethodMap.TryGetValue(option, out var method))
        {
            return method.Invoke(displayable);
        }
        
        return new List<IDisplayable>();
    }
}
