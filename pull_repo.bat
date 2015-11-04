
@echo off

echo --- Pulling repository and submodules ---
git pull
git submodule foreach git pull
git submodule foreach git checkout master