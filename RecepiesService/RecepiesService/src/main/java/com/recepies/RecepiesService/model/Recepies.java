package com.recepies.RecepiesService.model;

import java.io.Serializable;
import java.util.ArrayList;

public class Recepies  implements Serializable  {

    private ArrayList<Recepie> recepies = new ArrayList<>();

    public Recepies() {
        recepies = new ArrayList<>();
    }

    public ArrayList<Recepie> getRecepies() {
        return recepies;
    }

    public void setRecepies(ArrayList<Recepie> recepies) {
        this.recepies = recepies;
    }
}
