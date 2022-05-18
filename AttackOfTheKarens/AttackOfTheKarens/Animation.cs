using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttackOfTheKarens {

    /// <summary>
    /// A frame animation contains a list of images. Each image must be added individually. Animations should be
    /// Update()'ed each tick. After a certain amount of time has passed (int total_time), the current
    /// frame/image (curAni) of the animation will change to the next image in the list. Loops back to
    /// image 0 after the end of the list has been reached.
    /// </summary>
    public class FrameAnimation {

        //an animation contains a list of images
        private LinkedList<Image> imageList;

        //what image is currently being used
        private int curAni;

        //the total amount of time each frame/image is displayed
        private int total_time;

        //how much time has passed since last frame
        private int cur_time;

        //if cur_time has reached total_time, the next image is ready
        private bool imageReady;

        //once all desired frames of an animation have been 
        private bool complete;

        //how many entities are using this animation
        private int entityCount;

        /// <summary>
        /// Create an animation where each frame lasts for the desired amount of time. 1 total_time = 0.1 seconds.
        /// </summary>
        /// <param name="total_time"></param>
        public FrameAnimation(int total_time) {
            this.total_time = total_time;
            this.entityCount = 1;

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
        public Image GetImage() {
            if (!imageReady) { throw new Exception("Cannot call GetImage() if image is not available."); }
            imageReady = false;
            return imageList.ElementAt(curAni);
        }

        /// <summary>
        /// If multiple entities use this animation, "imageReady" must be manually set
        /// </summary>
        /// <returns></returns>
        public Image GetImageMulti() {
            return imageList.ElementAt(curAni);
        }

        /// <summary>
        /// Should be executed each tick. Keeps track of animation timer and sets the next image to be ready once the current frame time has
        /// reached the total frame time.
        /// </summary>
        public void Update() {

            //keep track of time
            if (cur_time < total_time) { cur_time++; }

            //if total time has been reached, reset timer, go to next image, and set image to ready.
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
        public bool ImageReady() { return imageReady; }

        /// <summary>
        /// Force image to no longer be ready (used for animations that are tied to multiple entities)
        /// </summary>
        public void ImageGotten() { imageReady = false; }
    }

    /// <summary>
    /// A move animation calculates how far an image shoud move in a certain direction during a frame based on a given speed.
    /// </summary>
    public class MoveAnimation {

        //where the image started
        private int topStart;
        private int leftStart;

        //how far the image should move in total
        private int dY;
        private int dX;

        //how far the image has moved so far
        private float curY;
        private float curX;

        //how far the image will move this frame
        private float moveY;
        private float moveX;

        //whether or not the animation is finished
        private bool done;

        /// <summary>
        /// Create a move animation that allows an image to travel in a direction based on the given speed. Give this object the
        /// starting position of the image, how far it should move in total, and the speed that the image should move. Speed is a
        /// percentage. An image will move at the given percentage of the total given distance every frame.
        /// </summary>
        /// <param name="topStart"></param>
        /// <param name="leftStart"></param>
        /// <param name="dY"></param>
        /// <param name="dX"></param>
        /// <param name="speed"></param>
        /// <exception cref="Exception"></exception>
        public MoveAnimation(int topStart, int leftStart, int dY, int dX, float speed) {

            //speed is a percentage of the total distance and should not be negative or above 100. 
            if (speed > 100 || speed < 0) { throw new Exception("Speed must be in between 0 and 100 percent."); }

            this.topStart = topStart;
            this.leftStart = leftStart;
            this.curY = 0;
            this.curX = 0;
            this.dY = dY;
            this.dX = dX;

            //calculate how far the image should move every frame based off speed
            this.moveY = dY * speed / 100;
            this.moveX = dX * speed / 100;

            //animation does not begin done
            this.done = false;
        }

        /// <summary>
        /// Update this animation every tick. Update() will calculate how far the image should move, and whether or not
        /// the animation has finished yet.
        /// </summary>
        public void Update() {
            curY = curY + moveY;
            curX = curX + moveX;

            if (curX > dX && dX > 0 || curY > dY && dY > 0 || curX < dX && dX < 0 || curY < dY && dY < 0) { curX = dX; curY = dY; done = true; }
        }

        /// <summary>
        /// Get the current Y position of the image.
        /// </summary>
        /// <returns></returns>
        public int GetTop() { return (int) (topStart + curY); }
        /// <summary>
        /// Get the current X position of the image.
        /// </summary>
        /// <returns></returns>
        public int GetLeft() { return (int) (leftStart + curX); }
        /// <summary>
        /// Determine whether or not the animation has finished.
        /// </summary>
        /// <returns></returns>
        public bool isDone() { return done; }
    }
}