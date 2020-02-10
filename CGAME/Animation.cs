using System.Drawing;

namespace CGAME
{
    [System.Serializable]
    public class Animation
    {
        private Sprite sprite;
        private Image[] images;

        private int currentIndex = 0;

        private double timeStep = 0.25; // 1/4
        private double timer = 0f;

        public bool isPlay { get; private set; }

        public Animation(Sprite _sprite, Image[] _images, double _timeStep = 0.25, bool _playOnAwake = false)
        {
            sprite = _sprite;
            images = _images;
            timeStep = _timeStep;
            isPlay = _playOnAwake;

            if (isPlay) Play();
        }

        public void Play()
        {
            isPlay = true;
        }

        public void Stop()
        {
            isPlay = false;
        }

        public void Update()
        {
            if (!isPlay) return;

            if (images.Length == 1) return;

            timer += Time.deltaTime;

            if (timer >= timeStep)
            {
                timer = 0f;

                if (currentIndex >= images.Length)
                {
                    currentIndex = 0;
                }

                sprite.UpdateImage(images[currentIndex++]);
            }
        }
    }
}
