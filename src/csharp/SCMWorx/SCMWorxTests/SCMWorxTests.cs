using NUnit.Framework;
using System.Collections.Generic;

namespace SCMWorx
{
    public class SCMWorxTests
    {
        [Test]
        public void TestLoadData()
        {
            DataPreprocessing preprocessing = new DataPreprocessing();
            preprocessing.LoadData("data/supply_chain_data.csv");
            List<double[]> features = preprocessing.GetFeatures();
            List<int> labels = preprocessing.GetLabels();

            Assert.AreEqual(features.Count, labels.Count);
        }

        [Test]
        public void TestTrainAndPredict()
        {
            DataPreprocessing preprocessing = new DataPreprocessing();
            preprocessing.LoadData("data/supply_chain_data.csv");

            SupplyChainModel model = new SupplyChainModel();
            model.Train(preprocessing.GetFeatures(), preprocessing.GetLabels());

            RiskPrediction predictor = new RiskPrediction(model);
            predictor.PredictRisk(preprocessing.GetFeatures());

            double[] predictions = model.Predict(preprocessing.GetFeatures());
            Assert.AreEqual(predictions.Length, preprocessing.GetFeatures().Count);
        }
    }
}
