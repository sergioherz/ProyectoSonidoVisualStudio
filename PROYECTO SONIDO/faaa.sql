-- MySQL Script generated by MySQL Workbench
-- Fri Apr 20 14:50:07 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema faraon
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema faraon
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `faraon` DEFAULT CHARACTER SET utf8 ;
USE `faraon` ;

-- -----------------------------------------------------
-- Table `faraon`.`Paquetes`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `faraon`.`Paquetes` ;

CREATE TABLE IF NOT EXISTS `faraon`.`Paquetes` (
  `id_paq` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(30) NULL,
  `Costo` INT NULL,
  `Descripción` VARCHAR(60) NULL,
  PRIMARY KEY (`id_paq`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `faraon`.`Contratos`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `faraon`.`Contratos` ;

CREATE TABLE IF NOT EXISTS `faraon`.`Contratos` (
  `id_con` INT NOT NULL AUTO_INCREMENT,
  `Nombre_persona` VARCHAR(45) NULL,
  `Dirección` VARCHAR(45) NULL,
  `Telefono` VARCHAR(45) NULL,
  `Fecha` DATE NULL,
  `Paquetes_id_paq` INT NOT NULL,
  PRIMARY KEY (`id_con`),
  INDEX `fk_Contratos_Paquetes_idx` (`Paquetes_id_paq` ASC),
  CONSTRAINT `fk_Contratos_Paquetes`
    FOREIGN KEY (`Paquetes_id_paq`)
    REFERENCES `faraon`.`Paquetes` (`id_paq`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `faraon`.`Trabajadores`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `faraon`.`Trabajadores` ;

CREATE TABLE IF NOT EXISTS `faraon`.`Trabajadores` (
  `id_trabajador` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NULL,
  `Telefono` VARCHAR(10) NULL,
  `Edad` VARCHAR(11) NULL,
  `Dirección` VARCHAR(45) NULL,
  PRIMARY KEY (`id_trabajador`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `faraon`.`Inventario`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `faraon`.`Inventario` ;

CREATE TABLE IF NOT EXISTS `faraon`.`Inventario` (
  `id_inven` INT NOT NULL AUTO_INCREMENT,
  `Nombre_producto` VARCHAR(45) NULL,
  `Tipo` VARCHAR(45) NULL,
  `Status` VARCHAR(40) NULL,
  `Costo` INT NULL,
  PRIMARY KEY (`id_inven`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
