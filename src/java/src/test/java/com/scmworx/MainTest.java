package com.scmworx;

import org.junit.Test;

import java.util.List;

import static org.junit.Assert.assertEquals;

public class MainTest {

    @Test
    public void testLoadData() {
        DataPreprocessing preprocessing = new DataPreprocessing();
        preprocessing.loadData("data/supply_chain_data.csv");
        List<double[]> features = preprocessing.getFeatures();
        List<Integer> labels = preprocessing.getLabels();

        assertEquals(features.size(), labels.size());
    }

    @Test
    public void testTrainAndPredict() {
        DataPreprocessing preprocessing = new DataPreprocessing();
        preprocessing.loadData("data/supply_chain_data.csv");

        SupplyChainModel model = new SupplyChainModel();
        model.train(preprocessing.getFeatures(), preprocessing.getLabels());

        RiskPrediction predictor = new RiskPrediction(model);
        predictor.predictRisk(preprocessing.getFeatures());

        double[] predictions = model.predict(preprocessing.getFeatures());
        assertEquals(predictions.length, preprocessing.getFeatures().size());
    }
}
