using RandomPictureGenLib.PictureGenInterfaces;
namespace RandomPictureGenLib.PictureGen
{
    public class RandomPicture
    {
        public ImageAbstraction imageAbstraction { get; private set;}
        public WindowsPictureSaver pictureSaver { get; private set;}

        public RandomPicture(int width, int heigh)
        {
            this.imageAbstraction = new ImageAbstraction(width, heigh);
            pictureSaver = new WindowsPictureSaver();
        }

        public void PictureCreate()
        {
            pictureSaver.CreatePicture(imageAbstraction.CreateImageAbstraction());
        }

        public void PictureSaveToJpg(string destinationPath)
        {
            pictureSaver.SaveJpg(destinationPath);
        }

        public void PictureSaveToBmp(string destinationPath)
        {
            pictureSaver.SaveBmp(destinationPath);
        }
    }
}