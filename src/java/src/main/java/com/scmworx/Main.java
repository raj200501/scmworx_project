package com.scmworx;

public class Main {
    public static void main(String[] args) {
        DataPreprocessing preprocessing = new DataPreprocessing();
        preprocessing.loadData("data/supply_chain_data.csv");

        SupplyChainModel model = new SupplyChainModel();
        model.train(preprocessing.getFeatures(), preprocessing.getLabels());

        RiskPrediction predictor = new RiskPrediction(model);
        predictor.predictRisk(preprocessing.getFeatures());
    }
}
