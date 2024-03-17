import codecs
import os
import sys

notSearchingDirectories = set([
    "obj",
    "bin",
    "Debug",
    "Release"
])

def search_directory(path):
    filesToConvert = []
    for (dirpath, directories, filenames) in os.walk(path):
        for directory in directories:
            if (directory not in notSearchingDirectories):
                deepFiles = search_directory(dirpath + directory)
                filesToConvert.extend(deepFiles)
        for filename in filenames:
            if filename.endswith(".cs"):
                filesToConvert.append(dirpath + "\\" + filename)
    return filesToConvert

def fix_encoding(path):
        with open(path, 'rb') as f:
            raw = f.read()
        
        if raw.startswith(codecs.BOM_UTF8):
            pass
        else:
            with codecs.open(path, mode='r', encoding='utf-8') as utf8File:
                content = utf8File.read()
                with codecs.open(path, mode='w', encoding='utf-8-sig') as utf8WithBomFile:
                    utf8WithBomFile.write(content)
                    print "rewrited file " + path

path = sys.argv[1]
for filename in search_directory(path):
    fix_encoding(filename)
