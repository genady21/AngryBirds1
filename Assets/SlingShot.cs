using System;
using System.Collections;
using UnityEngine;

namespace Scenes
{
    public class SlingShot :MonoBehaviour
    {
        [SerializeField]
        private BirdTransfer birdTransfer;

        [SerializeField] private float slingPower = 25;
        [SerializeField] private int count = 3;
        [SerializeField] private ShotPoint shotPoint;
        [SerializeField] private BirdSource source;

        private IEnumerator Start()
        {
            for (int i = 0; i < count; i++)
            {
                var bird = source.GitBird();
                yield return SeatBird(bird);
                yield return WaitForShot(bird);
            }
        }

        private IEnumerator WaitForShot(Bird bird)
        {
            var isDone = false;

            void Shot(Vector2 direction)
            {
                isDone = true;
                bird.Launch(direction*-slingPower);
            }
            shotPoint.onRelease.AddListener(Shot);

            while (!isDone)
            {
                bird.transform.position = shotPoint.transform.position;
                yield return null;
            }
            shotPoint.onRelease.RemoveAllListeners();
        }

        private IEnumerator SeatBird(Bird bird)
        {
            shotPoint.enabled = false;
            yield return birdTransfer.TransferBird(bird, shotPoint.transform.position);
            shotPoint.enabled = true;
            
        }
    }
}