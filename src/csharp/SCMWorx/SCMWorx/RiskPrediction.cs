using System;
using System.Collections.Generic;

namespace SCMWorx
{
    public class RiskPrediction
    {
        private readonly SupplyChainModel model;

        public RiskPrediction(SupplyChainModel model)
        {
            this.model = model;
        }

        public void PredictRisk(List<double[]> features)
        {
            double[] predictions = model.Predict(features);
            for (int i = 0; i < predictions.Length; i++)
            {
                Console.WriteLine("Prediction for instance " + i + ": " + (predictions[i] > 0.5 ? "High Risk" : "Low Risk"));
            }
        }
    }
}
