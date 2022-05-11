using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttackOfTheKarens {

    /// <summary>
    /// An animation contains a list of images. Each image must be added individually. Animations should be
    /// Update()'ed each tick. After a certain amount of time has passed (int total_time), the current
    /// frame/image (curAni) of the animation will change to the next image in the list. Loops back to
    /// image 0 after the end of the list has been reached.
    /// </summary>
    public class Animation {

        //an animation contains a list of images
        private LinkedList<Image> imageList;

        //what image is currently being used
        private int curAni;

        //the total amount of time each frame/image is displayed
        private int total_time;

        //how much time has passed since last frame
        private int cur_time;

        //if cur_time has reached total_time, the next image is ready
        private Boolean imageReady;

        //once all desired frames of an animation have been 
        private Boolean complete;

        /// <summary>
        /// Create an animation where each frame lasts for the desired amount of time. 1 total_time = 0.1 seconds.
        /// </summary>
        /// <param name="total_time"></param>
        public Animation(int total_time) {
            this.total_time = total_time;

            //default states
            this.curAni = 0;
            this.cur_time = 0;
            this.imageReady = false;
            this.complete = false;

            //create the list
            this.imageList = new LinkedList<Image>();
        }

        /// <summary>
        /// Add an image to the end of the list of images. Fails if Complete() has been executed already.
        /// </summary>
        /// <param name="img"></param>
        public void Add(Image img) {
            if (complete) { throw new Exception("Image list already completed, cannot add more images after completion."); }
            imageList.AddLast(img);
        }

        /// <summary>
        /// Complete the list of images so that no more can be added. Returns the first image in the list. 
        /// Fails if Complete() has been executed already.
        /// </summary>
        /// <returns></returns>
        public Image Complete() {
            if (complete) { throw new Exception("Image list already completed, cannot complete more than once."); }
            complete = true;
            return imageList.ElementAt(0);
        }

        /// <summary>
        /// Return the image that is currently being used. Fails if ImageReady() returns false.
        /// </summary>
        /// <returns></returns>
        public Image GetImage()
        {

            if (!imageReady) { throw new Exception("Cannot call GetImage() if image is not available."); }

            //image is being returned, so image is no longer ready
            imageReady = false;

            return imageList.ElementAt(curAni);
        }

        /// <summary>
        /// Should be executed each tick. Keeps track of animation timer and sets the next image to be ready once the current frame time has
        /// reached the total frame time.
        /// </summary>
        public void Update() {

            //keep track of time
            if (cur_time < total_time) { cur_time++; }

            //if total time has been reached, go to next image and set image to ready.
            else {
                cur_time = 0;
                curAni++;
                if (curAni == imageList.Count) { curAni = 0; }
                imageReady = true;
            }
        }

        /// <summary>
        /// Returns true if the animation is ready to go to the next image (frame time is up).
        /// </summary>
        /// <returns></returns>
        public Boolean ImageReady() { return imageReady; }
    }
}
