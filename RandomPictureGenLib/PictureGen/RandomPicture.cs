using RandomPictureGenLib.PictureGenInterfaces;
namespace RandomPictureGenLib.PictureGen
{
    public class RandomPicture
    {
        public IImageAbstraction imageAbstraction { get; private set;}
        public IPictureSaver pictureSaver { get; private set;}

        public RandomPicture(IImageAbstraction imageAbstraction, IPictureSaver pictureSaver)
        {
            this.imageAbstraction = imageAbstraction;
            this.pictureSaver = pictureSaver;
        }

        public void PictureSaveToJpg(string destinationPath)
        {
            pictureSaver.SaveJpg(destinationPath, imageAbstraction.CreateImageAbstraction());
        }

        public void PictureSaveToBmp(string destinationPath)
        {
            pictureSaver.SaveBmp(destinationPath, imageAbstraction.CreateImageAbstraction());
        }
    }
}