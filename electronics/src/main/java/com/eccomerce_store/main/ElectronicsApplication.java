package com.eccomerce_store.main;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.persistence.autoconfigure.EntityScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

@EnableJpaRepositories(basePackages = "com.eccomerce_store.repository")
@EntityScan(basePackages = "com.eccomerce_store.electronics")
@SpringBootApplication(scanBasePackages = "com.eccomerce_store")
public class ElectronicsApplication {

	public static void main(String[] args) {

        SpringApplication.run(ElectronicsApplication.class, args);
	}
}
