INSERT INTO oncogenes (Id, Symbol, Name, CancerSyndrome, TumorTypes, RoleInCancer)
VALUES 
(1, 'BRCA1', 'šeiminio krūties/kiaušidžių vėžio genas 1', 'paveldimas krūties ir kiaušidžių vėžys', 'kiaušidžių', 'naviko slopinimo genas'),
(2, 'BRCA2', 'šeimyninis krūties/kiaušidžių vėžio genas 2', 'paveldimas krūties ir kiaušidžių vėžys', 'krūties, kiaušidžių, kasos', 'naviko slopinimo genas');

SELECT * FROM oncogenes.oncogenes;