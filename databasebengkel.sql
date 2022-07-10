-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Inang: 127.0.0.1
-- Waktu pembuatan: 10 Jul 2022 pada 08.32
-- Versi Server: 5.5.32
-- Versi PHP: 5.4.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Basis data: `databasebengkel`
--
CREATE DATABASE IF NOT EXISTS `databasebengkel` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `databasebengkel`;

-- --------------------------------------------------------

--
-- Struktur dari tabel `bonpembelian`
--

CREATE TABLE IF NOT EXISTS `bonpembelian` (
  `NoFaktur` varchar(20) NOT NULL,
  `Tanggal` date NOT NULL,
  `NoPol` varchar(10) NOT NULL,
  `IDMekanik` varchar(5) NOT NULL,
  `potongan` int(11) NOT NULL,
  PRIMARY KEY (`NoFaktur`),
  KEY `IDMekanik` (`IDMekanik`),
  KEY `NoPol_2` (`NoPol`),
  KEY `NoFaktur` (`NoFaktur`),
  KEY `NoPol` (`NoPol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `bonpembelian`
--

INSERT INTO `bonpembelian` (`NoFaktur`, `Tanggal`, `NoPol`, `IDMekanik`, `potongan`) VALUES
('00000001', '2017-12-09', 'A555HA', '1', 0),
('123456', '2022-07-08', 'A1827TA', '1', 0),
('SIJ/2017/00000001', '2017-12-10', 'A555HA', '4', 0),
('SIJ/2017/000002', '2017-12-10', 'A1827TA', '3', 0),
('SIJ/2017/000003', '2017-12-10', 'b0090aa', '4', 0),
('SIJ/2017/000004', '2017-12-12', 'A555HA', '1', 0);

-- --------------------------------------------------------

--
-- Struktur dari tabel `daftar`
--

CREATE TABLE IF NOT EXISTS `daftar` (
  `username` varchar(25) NOT NULL,
  `password` varchar(25) NOT NULL,
  `level` varchar(16) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `daftar`
--

INSERT INTO `daftar` (`username`, `password`, `level`) VALUES
('admin', 'admin', 'Admin'),
('cs1', 'cs1', 'Customer Service');

-- --------------------------------------------------------

--
-- Struktur dari tabel `kendaraan`
--

CREATE TABLE IF NOT EXISTS `kendaraan` (
  `NoPol` char(10) NOT NULL DEFAULT '',
  `warna` char(8) NOT NULL,
  `merek` char(15) NOT NULL,
  `tahun` char(5) NOT NULL,
  PRIMARY KEY (`NoPol`),
  KEY `NoPol` (`NoPol`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `kendaraan`
--

INSERT INTO `kendaraan` (`NoPol`, `warna`, `merek`, `tahun`) VALUES
('', '', '', ''),
('A1827TA', 'Silver', 'Vario 150', '2015'),
('A555HA', 'HIJAU', 'NINJA', '2009'),
('B001GO', 'Merah', 'Yamaha', '2017'),
('b0090aa', 'silver', 'honda', '2017'),
('B10015', 'silver', 'honda', '2015'),
('B1035NKX', 'Abu abu', 'KIA RIO', '2013'),
('B111YA', 'HITAM', 'NINJA', '2016'),
('B212AA', 'Biru', 'Supra X', '2005'),
('B3117LB', 'Merah', 'Mio', '2008'),
('B9021K', 'UNGU', 'TOYOTA', '1999'),
('B9090GG', 'Gold', 'Suzuki', '2017'),
('B909CSG', 'Kuning', 'Yamaha', '2017'),
('BH12LU', 'UNGU', 'KYT', '2017'),
('F0190JJ', 'Hitam', 'Honda', '2017'),
('F1903FA', 'HITAM', 'SATRIA F', '2010');

-- --------------------------------------------------------

--
-- Struktur dari tabel `mekanik`
--

CREATE TABLE IF NOT EXISTS `mekanik` (
  `IDMekanik` char(5) NOT NULL,
  `NamaMekanik` varchar(25) NOT NULL,
  PRIMARY KEY (`IDMekanik`),
  KEY `IDMekanik` (`IDMekanik`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `mekanik`
--

INSERT INTO `mekanik` (`IDMekanik`, `NamaMekanik`) VALUES
('1', 'Gus'),
('2', 'mambray'),
('3', 'Bimaa'),
('4', 'Jess'),
('5', 'irvan maulana'),
('6', 'Koko'),
('7', 'pokcou'),
('8', 'harun');

-- --------------------------------------------------------

--
-- Struktur dari tabel `parts`
--

CREATE TABLE IF NOT EXISTS `parts` (
  `KodeParts` char(5) NOT NULL,
  `NamaParts` varchar(50) NOT NULL,
  `Harga` int(11) NOT NULL,
  `stok` int(11) NOT NULL,
  PRIMARY KEY (`KodeParts`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `parts`
--

INSERT INTO `parts` (`KodeParts`, `NamaParts`, `Harga`, `stok`) VALUES
('1294G', 'Jok Sportivo', 90000, 1),
('23123', 'OLI FEDERAL MATIC', 50000, 7),
('2353A', 'Oli TOP 1', 27000, 7),
('29023', 'ban dalam swallow', 25000, 10),
('52312', 'Ban FDR 90/90', 50000, 7),
('BA321', 'Sportivo Tubeless', 150000, 8),
('P001', 'OLI GARDAN', 10000, 9);

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksiparts`
--

CREATE TABLE IF NOT EXISTS `transaksiparts` (
  `NoFaktur` varchar(20) NOT NULL,
  `KodeParts` char(5) NOT NULL,
  `Qty` int(11) NOT NULL,
  `Harga` int(11) NOT NULL,
  `Diskon` int(11) NOT NULL,
  KEY `KodeParts` (`KodeParts`,`NoFaktur`),
  KEY `NoFaktur_2` (`NoFaktur`),
  KEY `NoFaktur` (`NoFaktur`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `transaksiparts`
--

INSERT INTO `transaksiparts` (`NoFaktur`, `KodeParts`, `Qty`, `Harga`, `Diskon`) VALUES
('2222222222', '1294G', 1, 90000, 5000),
('1111111111', '1294G', 1, 90000, 4500),
('1111111111', '23123', 2, 50000, 5000),
('3213123123', 'BA321', 2, 150000, 0),
('2131231231', '23123', 1, 50000, 0),
('05103217', '52312', 2, 50909, 3000),
('1111111111', '1294G', 0, 90000, 9000),
('3890192017', 'P001', 1, 10000, 5000),
('5432154321', '29023', 1, 25000, 1250),
('5432154321', '2353A', 1, 27000, 0),
('1111111111', 'P001', 1, 10000, 0),
('5432154321', '2353A', 1, 27000, 1350),
('1221219012', 'P001', 1, 10000, 500),
('SIJ/2017/00000001', 'P001', 1, 2000, 0),
('SIJ/2017/000002', '23123', 1, 50000, 2500),
('SIJ/2017/000004', '1294G', 0, 90000, 0),
('SIJ/2017/000004', '23123', 1, 50000, 0),
('SIJ/2017/000004', '2353A', 1, 27000, 0),
('SIJ/2017/000004', '29023', 1, 25000, 0),
('SIJ/2017/000004', 'P001', 1, 10000, 0),
('SIJ/2017/000005', '23123', 1, 50000, 0),
('SIJ/2017/000003', '23123', 1, 50000, 0),
('SIJ/2017/000004', '1294G', 1, 90000, 4500),
('123456', '1294G', 1, 90000, 5000);

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `bonpembelian`
--
ALTER TABLE `bonpembelian`
  ADD CONSTRAINT `nopola` FOREIGN KEY (`NoPol`) REFERENCES `kendaraan` (`NoPol`);

--
-- Ketidakleluasaan untuk tabel `transaksiparts`
--
ALTER TABLE `transaksiparts`
  ADD CONSTRAINT `FK_Parts` FOREIGN KEY (`KodeParts`) REFERENCES `parts` (`KodeParts`) ON DELETE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
