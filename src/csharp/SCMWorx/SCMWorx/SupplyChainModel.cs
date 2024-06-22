using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace SCMWorx
{
    public class SupplyChainModel
    {
        private Matrix<double> weights;

        public void Train(List<double[]> features, List<int> labels)
        {
            int numFeatures = features[0].Length;
            weights = Matrix<double>.Build.Dense(numFeatures, 1);

            // Simple logistic regression training for demonstration
            for (int i = 0; i < features.Count; i++)
            {
                var featureVector = Vector<double>.Build.Dense(features[i]);
                double label = labels[i];
                double prediction = PredictSingle(featureVector);
                var gradient = featureVector * (label - prediction);
                weights += gradient.ToColumnMatrix();
            }
        }

        public double PredictSingle(Vector<double> features)
        {
            double z = weights.Transpose().Multiply(features).Sum();
            return 1 / (1 + Math.Exp(-z));
        }

        public double[] Predict(List<double[]> features)
        {
            double[] predictions = new double[features.Count];
            for (int i = 0; i < features.Count; i++)
            {
                predictions[i] = PredictSingle(Vector<double>.Build.Dense(features[i]));
            }
            return predictions;
        }
    }
}
