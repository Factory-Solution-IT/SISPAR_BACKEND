USE sispardb;


CREATE TABLE TITHER
(
	ID_TITHER	  				INT 			 IDENTITY(1, 1)		NOT NULL,
    NAME_TITHER  				VARCHAR(100)				NULL,
    ADDRESS_TITHER				VARCHAR(200)				NULL,
    NUMBER_TITHER				INT							NULL,
    NEIGHBORHOOD				VARCHAR(100)				NULL,
    E_MAIL						VARCHAR(100)				NULL,
    CELLPHONE					VARCHAR(20)					NULL,
    TELEPHONE					VARCHAR(20)					NULL,
    BIRTH_DATE					DATE					NOT	NULL,
    MARRIAGE_DATE				DATE						NULL,
	NAME_SPOUSE					VARCHAR(100)				NULL,
    BIRTH_DATE_SPOUSE			DATE						NULL,
    NAME_SON					VARCHAR(100)				NULL,
	BIRTH_DATE_SON				DATE						NULL,
    
    PRIMARY KEY CLUSTERED (ID_TITHER)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)

);