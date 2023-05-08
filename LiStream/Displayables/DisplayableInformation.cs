using LiStream.Displayables.Interfaces;

namespace LiStream.Displayables
{
    public record DisplayableInformation(string Header, string Information) : IDisplayableInformation;
}
