/*
  Warnings:

  - Made the column `description` on table `Transaction` required. This step will fail if there are existing NULL values in that column.

*/
-- AlterTable
ALTER TABLE `Transaction` MODIFY `description` VARCHAR(191) NOT NULL;
