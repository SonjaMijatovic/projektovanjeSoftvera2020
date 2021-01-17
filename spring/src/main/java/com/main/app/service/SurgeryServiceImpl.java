package com.main.app.service;

import com.main.app.domain.model.Surgery;
import com.main.app.domain.model.user.User;
import com.main.app.repository.user.SurgeryRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class SurgeryServiceImpl implements SurgeryService {

    private SurgeryRepository surgeryRepository;

    @Autowired
    public SurgeryServiceImpl(SurgeryRepository surgeryRepository) {
        this.surgeryRepository = surgeryRepository;
    }

    @Override
    public Page<Surgery> findAllByPatient(User patient, Pageable pageable) {
        return surgeryRepository.findAllByPatient(patient, pageable);
    }

    @Override
    public Surgery save(Surgery surgery) {
        return surgeryRepository.save(surgery);
    }
}
