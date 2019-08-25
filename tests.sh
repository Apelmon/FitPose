#!/bin/bash
clear
xbuild /property:Configuration=Release /verbosity:minimal Tests/Tests.sln
mono Tests/Tests/bin/Release/Tests.exe $@