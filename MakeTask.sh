#!/bin/bash

if [ $# -ne 2 ]; then
  echo "コンテスト名と問題数を指定してください"
  echo "./MakeTask.sh CONTESTNAME TASKNUMBER"
  exit
fi

CONTEST=$1
TASKNUMBER=$2

dotnet new -u "$(pwd)"/Template
dotnet new -i Template

cd src || exit

A=65 #アスキーコード
END=$((A+TASKNUMBER-1))

# Aから文字数分ループする
for i in $(seq $A $END)
do

  # アスキーコードを大文字アルファベットに変換する
  TASKKEY=$(printf "%b\n" "$(printf "%s%x" "\\x" "$i")")
  TASKNAME=$CONTEST$TASKKEY
  if [ ! -e "$TASKNAME" ]; then
    mkdir "$TASKNAME"
  else 
    continue
  fi
  
  cd "$TASKNAME" || exit
  dotnet new AtCoderTaskTemplate -n "$TASKNAME" --taskName "$TASKNAME"
  mv "./AtCoderTemplate.csproj" "./$TASKNAME.csproj"
  cd ../
  
  dotnet sln ../AtCoder.sln add "$TASKNAME"
done

#mkdir ${CONTEST}A && cd ${CONTEST}A && dotnet new AtCoderLibraryTemplate -n ${CONTEST}A