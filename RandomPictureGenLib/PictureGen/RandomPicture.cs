using RandomPictureGenLib.PictureGenInterfaces;
namespace RandomPictureGenLib.PictureGen
{
    public class RandomPicture
    {
        public IImageDTO imageAbstraction { get; private set;}
        private IPicCreate picture;
        private IPicSave pictureSaver;

        public RandomPicture(int width, int heigh)
        {
            this.imageAbstraction = new ImageDTO(width, heigh);
            picture = new PicCreate();
            pictureSaver = new PicSave();
        }

        public void PictureCreate()
        {
            picture.CreateImage(imageAbstraction);
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