using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Drawing;

namespace BellySlide
{
    public class ObjectDetectionService
    {
        private Image<Bgr, byte> rockTemplate;
        private Image<Bgr, byte> barTemplate;
        private Image<Bgr, byte> lavaPitTemplate;
        private Image<Bgr, byte> meteorTemplate;

        public ObjectDetectionService(string rockTemplatePath, string barTemplatePath, string lavaPitTemplatePath, string meteorTemplatePath)
        {
            this.rockTemplate = new Image<Bgr, byte>(rockTemplatePath);
            this.barTemplate = new Image<Bgr, byte>(barTemplatePath);
            this.lavaPitTemplate = new Image<Bgr, byte>(lavaPitTemplatePath);
            this.meteorTemplate = new Image<Bgr, byte>(meteorTemplatePath);
        }

        public List<GameObject> DetectObjects(Image<Bgr, byte> gameScreen)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            // Detect rocks
            List<Point> rockLocations = DetectObjects(gameScreen, rockTemplate);
            foreach (Point location in rockLocations)
            {
                gameObjects.Add(new GameObject { Type = GameObjectType.Rock, Location = location });
            }

            // Detect bars
            List<Point> barLocations = DetectObjects(gameScreen, barTemplate);
            foreach (Point location in barLocations)
            {
                gameObjects.Add(new GameObject { Type = GameObjectType.Bar, Location = location });
            }

            // Detect lava pits
            List<Point> lavaPitLocations = DetectObjects(gameScreen, lavaPitTemplate);
            foreach (Point location in lavaPitLocations)
            {
                gameObjects.Add(new GameObject { Type = GameObjectType.LavaPit, Location = location });
            }

            // Detect meteors
            List<Point> meteorLocations = DetectObjects(gameScreen, meteorTemplate);
            foreach (Point location in meteorLocations)
            {
                gameObjects.Add(new GameObject { Type = GameObjectType.Meteor, Location = location });
            }

            return gameObjects;
        }

        private List<Point> DetectObjects(Image<Bgr, byte> gameScreen, Image<Bgr, byte> template)
        {
            using (Image<Gray, float> result = gameScreen.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                return maxLocations.ToList();
            }
        }
    }


}
