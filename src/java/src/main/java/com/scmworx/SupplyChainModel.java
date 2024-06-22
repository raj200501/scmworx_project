package com.scmworx;

import org.apache.commons.math3.linear.MatrixUtils;
import org.apache.commons.math3.linear.RealMatrix;
import org.apache.commons.math3.linear.RealVector;

import java.util.List;

public class SupplyChainModel {
    private RealMatrix weights;

    public void train(List<double[]> features, List<Integer> labels) {
        int numFeatures = features.get(0).length;
        weights = MatrixUtils.createRealMatrix(numFeatures, 1);

        // Simple logistic regression training for demonstration
        for (int i = 0; i < features.size(); i++) {
            RealVector featureVector = MatrixUtils.createRealVector(features.get(i));
            double label = labels.get(i);
            double prediction = predictSingle(featureVector);
            RealVector gradient = featureVector.mapMultiply(label - prediction);
            weights = weights.add(gradient.outerProduct(MatrixUtils.createRealVector(new double[]{1})));
        }
    }

    public double predictSingle(RealVector features) {
        double z = weights.transpose().operate(features).getEntry(0);
        return 1 / (1 + Math.exp(-z));
    }

    public double[] predict(List<double[]> features) {
        double[] predictions = new double[features.size()];
        for (int i = 0; i < features.size(); i++) {
            predictions[i] = predictSingle(MatrixUtils.createRealVector(features.get(i)));
        }
        return predictions;
    }
}
