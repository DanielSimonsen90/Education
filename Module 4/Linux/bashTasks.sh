# Lav et script der leder efter filer på filsystemet. 
# Brugeren skal kunne angive et fil navn, 
# eller et filmønster (f.eks "*.sh") der skal ledes efter 
function One {
    ls -filter $1
}

# Lav et script der finder information om din PC's CPU og viser det på skærmen 
function Two {
    echo -e "Processor Name:\t\t"`awk -F':' '/^model name/ {print $2}' /proc/cpuinfo | uniq | sed -e 's/^[ \t]*//'`
}

# Lav et script der finder information din PC's RAM og viser det på skærmen
function Three {
    echo -e "Memory Usage:\t"`free | awk '/Mem/{printf("%.2f%"), $3/$2*100}'`
}

# Lav et script der finder information om din PC's diske og viser dem på skærmen 
function Four {
    df -Ph | sed s/%//g | awk '{ if($5 > 80) print $0;}'
}

# Find ud af om du kan finde noget der svarer til en eventlog, 
# og om du kan hente data derfra på samme måde, 
# som du gjorde i Powershell script'et
function Five {
    
}

# Source
#   https://www.2daygeek.com/bash-shell-script-view-linux-system-information/