package com.main.app.service;

import com.main.app.domain.model.Clinic;
import com.main.app.domain.model.Hall;
import com.main.app.repository.user.HallRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class HallServiceImpl implements HallService {

    private HallRepository hallRepository;

    @Autowired
    public HallServiceImpl(HallRepository hallRepository) {
        this.hallRepository = hallRepository;
    }

    @Override
    public List<Hall> findAllByClinic(Clinic clinic, Pageable pageable) {
        return hallRepository.findAllByClinic(clinic, pageable);
    }

    @Override
    public Hall save(Hall hall) {
        return hallRepository.save(hall);
    }
}
