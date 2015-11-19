
@echo off

echo --- Pulling repository and submodules ---
git pull origin master
git checkout
git submodule foreach git pull origin master
git submodule foreach git checkout