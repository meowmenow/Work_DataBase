GO 
USE ��������
CREATE TABLE �����(
��� INT NOT NULL,
����� NVARCHAR(25) NOT NULL,
��� INT NOT NULL,
�������� INT NOT NULL,
CONSTRAINT PK_�����_��������� PRIMARY KEY (���),
CONSTRAINT FK_�����_����� FOREIGN KEY (�����)
	REFERENCES ����� (�����)
	ON DELETE CASCADE
	ON UPDATE CASCADE,
CONSTRAINT FK_�����_��� FOREIGN KEY (���)
	REFERENCES ������� (���)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)

CREATE TABLE ������� (
���������� INT IDENTITY(1,1) NOT NULL,
����� NVARCHAR(10) NOT NULL,
�������������� INT NOT NULL ,
����������� INT NOT NULL,
CONSTRAINT PK_�������_���������� PRIMARY KEY (����������),

	CONSTRAINT FK_�������_����������� FOREIGN KEY (��������������)
		REFERENCES ����������� (���)
		ON DELETE CASCADE
		ON UPDATE CASCADE,

	CONSTRAINT FK_�������_����������� FOREIGN KEY (�����������)
		REFERENCES ������� (���)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)

CREATE TABLE ����������� (
	��� INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	����� NVARCHAR(10) NOT NULL,
	������ NVARCHAR(100) NOT NULL,
	������ NVARCHAR(1) NOT NULL,
	������� NVARCHAR(25) NOT NULL,
	��� NVARCHAR(25) NOT NULL
)	
