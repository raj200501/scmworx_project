using System;

namespace SCMWorx
{
    class Program
    {
        static void Main(string[] args)
        {
            DataPreprocessing preprocessing = new DataPreprocessing();
            preprocessing.LoadData("data/supply_chain_data.csv");

            SupplyChainModel model = new SupplyChainModel();
            model.Train(preprocessing.GetFeatures(), preprocessing.GetLabels());

            RiskPrediction predictor = new RiskPrediction(model);
            predictor.PredictRisk(preprocessing.GetFeatures());
        }
    }
}
