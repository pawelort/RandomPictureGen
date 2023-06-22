using RandomPictureGenLib.PictureGen;
namespace RandomPictureGenLib.PictureGenInterfaces
{
    public interface IPictureSaver
    {
        void Save(string path, ImageDTO imageAbstraction);
    }
}