package com.main.app.service;

import com.main.app.domain.model.Clinic;
import com.main.app.domain.model.Price;
import com.main.app.repository.user.PriceRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PriceServiceImpl implements PriceService {

    private PriceRepository priceRepository;

    @Autowired
    public PriceServiceImpl(PriceRepository priceRepository) {
        this.priceRepository = priceRepository;
    }

    @Override
    public List<Price> findAllByClinic(Clinic clinic, Pageable pageable) {
        return priceRepository.findAllByClinic(clinic, pageable);
    }

    @Override
    public Price save(Price price) {
        return priceRepository.save(price);
    }
}
