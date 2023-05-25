use oncogenes;

INSERT INTO oncogenes (Id, Symbol, Name, CancerSyndrome, TumorTypes)
VALUES 
(1, 'BRCA1', 'šeiminio krūties/kiaušidžių vėžio genas 1', 'paveldimas krūties ir kiaušidžių vėžys', 'kiaušidžių'),
(2, 'BRCA2', 'šeimyninis krūties/kiaušidžių vėžio genas 2', 'paveldimas krūties ir kiaušidžių vėžys', 'krūties, kiaušidžių, kasos'),
(3, 'ABL', 'v-abl Abelson murinų leukemijos virusinio onkogeno homologas 1', NULL, NULL);


INSERT INTO oncogenes.drugs (GenericDrugName)
VALUES 
('OlympiAD'),
('EMBRACA'),
('OlympiA'),
('SOLO-1'),
('SOLO-2'),
('ARIEL3 tBRCA group'),
('PAOLA-1'),
('NOVA'),
('Study 19'),
('POLO'),
('TRITON2'),
('PROfound cohort A'),
('PROfound cohort A'),
('PROfound cohort B'),
('Olaparib'),
('Imatinib'),
('Dasatinib'),
('Brigatinib'),
('Bosutinib'),
('Nilotinib');

INSERT INTO diseases (Id, Name)
VALUES
(1, 'Krūties vėžys'),
(2, 'Stemplės vėžys'),
(3, 'Odos vėžys'),
(4, 'Kasos vėžys'),
(5, 'Gimdos kaklelio vėžys'),
(6, 'Gliobastoma'),
(7, 'Šlapimo pūslės vėžys'),
(8, 'Kiaušidžių vėžys'),
(9, 'Skrandžio vėžys'),
(10, 'Storosios žarnos vėžys'),
(11, 'Tiesiosios žarnos vėžys'),
(12, 'Ryklės vėžys'),
(13, 'Gerklų vėžys'),
(14, 'Smulkialąstelinis plaučių vėžys'),
(15, 'Nesmulkialąstelinis plaučių vėžys'),
(16, 'Ankstyvosios priešinės liaukos vėžys'),
(17, 'Gimdos kūno vėžys'),
(18, 'Inkstų vėžys'),
(19, 'Burnos ertmės vėžys');

INSERT INTO oncogenes.diseasecodes (DiseaseClassificator, CodeType,  CodeDescription)
VALUES 
('C 50.0', 0, 'Spenelis ir areolė'),
('C 50.1', 0, 'Krūties centrinė dalis'),
('C 50.2', 0, 'Krūties viršutinis ir vidinis kvadrantas'),
('C 50.3', 0, 'Krūties apatinis ir vidinis kvadrantas'),
('C 50.4', 0, 'Krūties viršutinis ir išorinis kvadrantas'),
('C 50.5', 0, 'Krūties apatinis ir išorinis kvadrantas'),
('C 50.6', 0, 'Krūties pažastinė dalis'),
('C 50.8', 0, 'Krūties išplitęs pažeidimas'),
('C 50.9', 0, 'Krūtis, nepatikslinta'); 

INSERT INTO activations (OncogeneId, MutationRemark, ActionabilityRank, DevelopmentStatus, TestingRequired,
  TrialStatus, CompletionStatus, Info, NumberOfPatients, TreatedNumber, ControlNumber, ControlTreatment,
  TrialPrimaryCompletionDate, LastUpdated)
VALUES
  (1, 'BRCA1_nepatikslinta or BRCA2_nepatikslinta', 1, 1, 1, 3, 2, NULL, 302, 205, 97, 'Chemotherapy',
  '2016-12-09', '2022-02-21'),
  (1, 'BRCA1_nepatikslinta or BRCA2_nepatikslinta', 1, 1, 1, 5, 2, 'https://www.accessdata.fda.gov/drugsatfda_docs/label/2021/211651s008lbl.pdf',
  431, 287, 144, 'Chemotherapy', '2017-09-15', '2023-01-18'),
  (1, 'BRCA1_nepatikslinta or BRCA2_nepatikslinta', 1, 1, 1, 4, 2, 'https://www.accessdata.fda.gov/drugsatfda_docs/label/2022/208558s023lbl.pdf',
  1836, 921, 915, 'Placebo', '2020-03-27', '2022-10-18'),
  (2, 'BRCA1_nepatikslinta or BRCA2_nepatikslinta', 1, 1, 1, 3, 2, NULL, 302, 205, 97, 'Chemotherapy',
  '2016-12-09', '2022-02-21'),
  (2, 'BRCA1_nepatikslinta or BRCA2_nepatikslinta', 1, 1, 1, 5, 2, 'https://www.accessdata.fda.gov/drugsatfda_docs/label/2021/211651s008lbl.pdf',
  431, 287, 144, 'Chemotherapy', '2017-09-15', '2023-01-18'),
  (2, 'BRCA1_nepatikslinta or BRCA2_nepatikslinta', 1, 1, 1, 4, 2, 'https://www.accessdata.fda.gov/drugsatfda_docs/label/2022/208558s023lbl.pdf',
  1836, 921, 915, 'Placebo', '2020-03-27', '2022-10-18');
  
INSERT INTO drugactivation (ActivationId, DrugId)
VALUES
  (1, 15),
  (2, 16),
  (3, 15),
  (4, 15),
  (5, 16),
  (6, 15);
  
INSERT INTO medicaltests (Id, Name, Note) VALUES 
('Anamnezės surinkimas', ''),
('Objektyvus būklės įvertinimas, palpacijos', ''),
('bendras kraujo tyrimas', ''),
('Mamografija', ''),
('Krūtų MRT', 'rutiniškai nerekomenduojamas, bet daugiadalykė specialistų komanda gali rekomenduoti, ypač jei yra šeiminė anamnezė, nustomos BRCA mutacijos, moterims su krūtų implantais, lobulinės karcinomos atveju, prieš neoadjuvantinį gydymą arba kai nepakanka konvencinių radiologinių tyrimų pirminei naviko diagnozei nustatyti.'),
('Krūtų echoskopija', ''),
('Krūtinės ląstos rentgenograma', ''),
('Pilvo organų echoskopija', ''),
('Pathistologinis tyrimas, imunohistochemija', ''),
('Krūtinės ląstos KT', 'išplitusio krūties vėžio atveju, atliekami ne visiems, o tik pagal klinikinę situaciją atrinktiems'),
('Sritinių l/m echoskopija', 'išplitusio krūties vėžio atveju, atliekami ne visiems, o tik pagal klinikinę situaciją atrinktiems'),
('Plaučių rentgenologinis tyrimas', 'išplitusio krūties vėžio atveju, atliekami ne visiems, o tik pagal klinikinę situaciją atrinktiems'),
('Kaulų skenavimas', 'išplitusio krūties vėžio atveju, atliekami ne visiems, o tik pagal klinikinę situaciją atrinktiems'),
('PET-CT', 'išplitusio krūties vėžio atveju, atliekami ne visiems, o tik pagal klinikinę situaciją atrinktiems');

INSERT INTO diseasemedicaltests (DiseaseId, MedicalTestId)
VALUES
  (1, 1),
  (1, 2),
  (1, 3),
  (1, 4),
  (1, 5),
  (1, 6),
  (1, 7),
  (1, 8),
  (1, 9),
  (1, 10),
  (1, 11),
  (1, 12),
  (1, 13),
  (1, 14);
  
INSERT INTO oncogenesdiseases (DiseaseId, OncogeneId)
VALUES
  (1, 1),
  (1, 2);


INSERT INTO oncogeneresistancetodrug (DrugId, OncogeneId)
VALUES
  (16, 3),
  (17, 3),
  (19, 3),
  (20, 3);
  
  SELECT * FROM oncogenes.treatments;

INSERT INTO treatments (Name, Note) VALUES 
('Chirurginis', NULL),
('Spindulinė terapija', NULL),
('Chemoterapija', NULL),
('Hormonoterapija', 'išplitusio krūties vėžio atveju'),
('Biologinė terapija', 'išplitusio krūties vėžio atveju');

  
INSERT INTO oncogenes.diseasetreatments (DiseaseId, TreatmentId)
VALUES (1, 1),
       (2, 1),
       (3, 1),
       (4, 1),
       (5, 1);

