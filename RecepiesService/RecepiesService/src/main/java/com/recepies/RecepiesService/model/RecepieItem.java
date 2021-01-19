package com.recepies.RecepiesService.model;

import java.io.Serializable;

public class RecepieItem implements Serializable  {

    private Medicine medicine;
    private double count;

    public RecepieItem() {}
    public RecepieItem(Medicine medicine, double count) {
        this.medicine = medicine;
        this.count = count;
    }

    public Medicine getMedicine() {
        return medicine;
    }

    public void setMedicine(Medicine medicine) {
        this.medicine = medicine;
    }

    public double getCount() {
        return count;
    }

    public void setCount(double count) {
        this.count = count;
    }
}
