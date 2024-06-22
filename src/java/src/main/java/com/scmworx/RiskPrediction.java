package com.scmworx;

import java.util.List;

public class RiskPrediction {
    private final SupplyChainModel model;

    public RiskPrediction(SupplyChainModel model) {
        this.model = model;
    }

    public void predictRisk(List<double[]> features) {
        double[] predictions = model.predict(features);
        for (int i = 0; i < predictions.length; i++) {
            System.out.println("Prediction for instance " + i + ": " + (predictions[i] > 0.5 ? "High Risk" : "Low Risk"));
        }
    }
}
