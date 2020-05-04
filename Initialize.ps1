
Set-Alias ildasm.exe "${env:ProgramFiles(x86)}\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.2 Tools\x64\ildasm.exe"

Function Invoke-ILDasm {
    [CmdletBinding()]
    param(
        [string]$assemblyFilter
        , [string]$item
        , [switch]$ShowWindow
        , [switch]$NoIL
        , [switch]$typeListOnly
    )

    $ildasmPath = (Get-Command ildasm.exe).Definition
    if(! (Test-Path $ildasmPath ))
    {
        throw "Unable to find ildasm.exe in expected location"
    }

    $assemblyPath = Get-AssemblyPath $assemblyFilter

    [string[]]$argumentList = ,"`"$assemblyPath`""

    if(!$ShowWindow)
    {
        $argumentList = $argumentList,'/TEXT'
    }
    if($NoIL) {
        $argumentList = $argumentList,'/NOIL'
    }
    if($TypeListOnly) {
        $argumentList = $argumentList,"/TYPELIST"
    }
    if($item) {
        $argumentList = $argumentList,"/ITEM=$item"
    }
    $command = "& '$ildasmPath' $argumentList"

    Write-Host "$ildasmPath $argumentList" -ForegroundColor Cyan
    $LASTEXITCODE = 0
    [bool]$insideTypeList = $false
    Invoke-Expression $command | Where-Object {
        if($typeListOnly)
        {
            if($_ -like "*.typelist*") {
                $insideTypeList = $true
            }
            elseif($_ -like '*}*') {
                $insideTypeList = $false
            }
            elseif($_ -like '*{*') {
                #ignore
            }
            elseif( $insideTypeList ) {
                Write-Output $true
            }
            else {
            }
        }
        else {
            Write-Output $true
        }
    }

    if($LASTEXITCODE -ne 0)
    {
        throw $err
    }

}
Set-Alias ildasm Invoke-ILDasm

Function Get-AssemblyPath {
    [CmdletBinding()]
    param(
        [string]$assemblyFilter
    )

    $assemblyPath = Resolve-Path $assemblyFilter
    if(!$assemblyPath -or (Test-Path $assemblyPath)) {
        $assemblyPath =  Get-ChildItem .\ $assemblyFilter -Recurse |
            Where-Object{ $_.Directory.FullName -notlike "*\obj\*"} |
            Select-Object -ExpandProperty FullName
    }

    if(@($assemblyPath).Count -gt 1) {
        throw "The assembly path is ambiguous"
    }

    if(!$assemblyPath) {
        throw "Unable to find assembly, '$assemblyFilter'"
    }
    Write-Output $assemblyPath
}


