using RandomPictureGenLib.PictureGen;
namespace RandomPictureGenLib.PictureGenInterfaces
{
    public interface IPictureSaver
    {
        void CreatePicture(ImageDTO imageAbstraction);
        void SaveJpg(string path);
        void SaveBmp(string path);
    }
}