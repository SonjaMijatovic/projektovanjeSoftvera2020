package com.recepies.RecepiesService.model;

import java.io.Serializable;
import java.util.ArrayList;

public class Recepie implements Serializable  {

    private int id;
    private Patient patient;
    private ArrayList<RecepieItem> items = new ArrayList<>();

    public Recepie() {}
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setPatient(int id, Patient patient) {
        this.patient = patient;
        this.id = id;
    }

    public void setItems(ArrayList<RecepieItem> items) {
        this.items = items;
    }

    public Patient getPatient() {
        return patient;
    }

    public ArrayList<RecepieItem> getItems() {
        return items;
    }

    public Recepie(Patient patient) {
        this.patient = patient;
    }
}
