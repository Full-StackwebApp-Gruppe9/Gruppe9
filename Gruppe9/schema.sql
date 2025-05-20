CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;
CREATE TABLE "ColorInfo" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_ColorInfo" PRIMARY KEY AUTOINCREMENT,
    "Red" INTEGER NOT NULL,
    "Green" INTEGER NOT NULL,
    "Blue" INTEGER NOT NULL
);

CREATE TABLE "DateInfo" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_DateInfo" PRIMARY KEY AUTOINCREMENT,
    "Dato" TEXT NOT NULL
);

CREATE TABLE "PollenRegistrering" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PollenRegistrering" PRIMARY KEY AUTOINCREMENT,
    "Date" TEXT NOT NULL,
    "TypeOfPollen" TEXT NOT NULL,
    "Level" INTEGER NOT NULL
);

CREATE TABLE "PlantInfo" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PlantInfo" PRIMARY KEY AUTOINCREMENT,
    "PlanteType" TEXT NOT NULL,
    "ColorInfoId" INTEGER NOT NULL,
    CONSTRAINT "FK_PlantInfo_ColorInfo_ColorInfoId" FOREIGN KEY ("ColorInfoId") REFERENCES "ColorInfo" ("Id") ON DELETE CASCADE
);

CREATE TABLE "PollenResponse" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_PollenResponse" PRIMARY KEY AUTOINCREMENT,
    "DateInfoId" INTEGER NOT NULL,
    "PlantInfoId" INTEGER NOT NULL,
    CONSTRAINT "FK_PollenResponse_DateInfo_DateInfoId" FOREIGN KEY ("DateInfoId") REFERENCES "DateInfo" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_PollenResponse_PlantInfo_PlantInfoId" FOREIGN KEY ("PlantInfoId") REFERENCES "PlantInfo" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_PlantInfo_ColorInfoId" ON "PlantInfo" ("ColorInfoId");

CREATE INDEX "IX_PollenResponse_DateInfoId" ON "PollenResponse" ("DateInfoId");

CREATE INDEX "IX_PollenResponse_PlantInfoId" ON "PollenResponse" ("PlantInfoId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250520141100_InitialCreate', '9.0.5');

COMMIT;

