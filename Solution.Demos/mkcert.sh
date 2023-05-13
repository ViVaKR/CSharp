#! /usr/local/bin/zsh

makecert -sr LocalMachine -ss root -r -n "CN=localhost" -sky exchange -sk 123456
