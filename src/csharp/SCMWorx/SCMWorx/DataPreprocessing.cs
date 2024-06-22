using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SCMWorx
{
    public class DataPreprocessing
    {
        private List<double[]> features = new List<double[]>();
        private List<int> labels = new List<int>();

        public void LoadData(string filepath)
        {
            var lines = File.ReadAllLines(filepath);
            foreach (var line in lines)
            {
                var values = line.Split(',');
                var feature = new double[values.Length - 1];
                for (int i = 0; i < values.Length - 1; i++)
                {
                    feature[i] = double.Parse(values[i]);
                }
                features.Add(feature);
                labels.Add(int.Parse(values.Last()));
            }
        }

        public List<double[]> GetFeatures()
        {
            return features;
        }

        public List<int> GetLabels()
        {
            return labels;
        }
    }
}
