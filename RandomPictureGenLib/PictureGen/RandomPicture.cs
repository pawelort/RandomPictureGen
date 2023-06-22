using RandomPictureGenLib.PictureGenInterfaces;
namespace RandomPictureGenLib.PictureGen
{
    public class RandomPicture
    {
        public IImageAbstraction imageAbstraction { get; private set;}
        public List<IPictureSaver> pictureSavers { get; private set;}

        public RandomPicture(IImageAbstraction imageAbstraction, List<IPictureSaver> pictureSavers)
        {
            this.imageAbstraction = imageAbstraction;
            this.pictureSavers = pictureSavers;
        }

        public void PictureSave(string destinationPath)
        {
            var imgDTO = imageAbstraction.CreateImageAbstraction();
            foreach(IPictureSaver picSaver in pictureSavers)
            {
                picSaver.Save(destinationPath, imgDTO);
            }

        }

    }
}