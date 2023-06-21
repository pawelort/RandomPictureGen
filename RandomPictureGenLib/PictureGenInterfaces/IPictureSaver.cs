using RandomPictureGenLib.PictureGen;
namespace RandomPictureGenLib.PictureGenInterfaces
{
    public interface IPictureSaver
    {
        void SaveJpg(string path, ImageDTO imageAbstraction);
        void SaveBmp(string path, ImageDTO imageAbstraction);
    }
}