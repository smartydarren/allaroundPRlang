# Install NPM modules file to another directory and include it in your projects
set olpt=C:\Darren\TestingData\npmpackages
set plpt=D:\Darren\TestingData\npmpackages

echo %olpt%

npm --prefix %olpt% install
npm --prefix %olpt% list

> pnpm --dir D:\TestingData\pnpm add formidable

pnpm link D:\TestingData\pnpm
pnpm link C:\Users\darre\OneDrive\Office\LEARNING\mycodepath\allaroundPRlang\nodejs\basics