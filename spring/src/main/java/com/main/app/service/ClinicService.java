package com.main.app.service;

import com.main.app.domain.model.Clinic;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

public interface ClinicService {

    Page<Clinic> findAll(Pageable pageable);
    Clinic save(Clinic save);
}
