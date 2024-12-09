;--------------------------------
;Inclusion Modern UI

  !include "MUI2.nsh"

;--------------------------------
;Les defines

  !define NOM_APP "Jardinage"

;--------------------------------
;Général

  ;Nom de l'application
  Name "${NOM_APP}"

  ;Nom du fichier de l'installateur
  OutFile "setup - ${NOM_APP}.exe"
  
  ;L'encodage du script doit être UTF-8 BOM
  Unicode True 


  ;Dossier d'installation par défaut
  ; InstallDir "$LOCALAPPDATA\${NOM_APP}"
  InstallDir "$PROGRAMFILES64\${NOM_APP}" #Droits admin requis

  ; Récupère le dossier d'installation du registre si l'application est 
  ; déjà installée et écrase la valeur par défaut InstallDir si c'est le cas
  InstallDirRegKey HKCU "Software\${NOM_APP}" ""

  ;Demande de privilège nécessaire pour l'installation
  RequestExecutionLevel admin #user # none|user|highest|admin

;--------------------------------
;Configuration de l'interface

  ; Permet de demander confirmation avant de quitter l'installateur
  !define MUI_ABORTWARNING  

  ; Forcera l'affichage de la fenêtre de dialogue pour le choix de la langue
  !define MUI_LANGDLL_ALWAYSSHOW
;--------------------------------
;Pages

  !insertmacro MUI_PAGE_COMPONENTS # Affiche les sections de l'installateur définies ci-bas
  !insertmacro MUI_PAGE_DIRECTORY # Sélection du dossier d'installation
  !insertmacro MUI_PAGE_INSTFILES # Installation des fichiers

  !insertmacro MUI_UNPAGE_CONFIRM # Confirmation de désinstallation
  !insertmacro MUI_UNPAGE_INSTFILES # Désinstallation des fichiers
  
;--------------------------------
;Langues de l'installateur
  !insertmacro MUI_LANGUAGE "French" # La langue par défaut est la première
  !insertmacro MUI_LANGUAGE "English"
  
;--------------------------------
;Les sections de l'installateur

Section "Rufus" SecComp1

  SetOutPath "$INSTDIR\bin"
  
  File /r "D:\_data\DSS\ADDA_1SS_exercices\ExempleEfCore\JardinageWpf\bin\Release\net8.0-windows\publish"

  ;Ajouter les fichiers à installer
  File "jardinage.exe"
  
  ;Ajouter au registre le dossier d'installation
  WriteRegStr HKCU "Software\${NOM_APP}" "" $INSTDIR
  
  ;Créer un désinstallateur
  WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

;--------------------------------
;Les traductions

  ;Les chaînes de traduction
  LangString DESC_SecComp1 ${LANG_FRENCH} "Glossaire de plantes"
  LangString DESC_SecComp1 ${LANG_ENGLISH} "Plants Atlas"

  ;Assignation des traduction aux sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecComp1} $(DESC_SecComp1)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Section du désinstallateur

Section "Uninstall"
  ;Suppression des éléments
  Delete "$INSTDIR\Uninstall.exe"
  RMDir /r "$INSTDIR\bin"
  ;NE JAMAIS FAIRE RMDir /r directement sur le dossier $INSTDIR : ***NON*** -->  RMDir /r "$INSTDIR"  <-- ***NON***
  ;Si jamais l'utilisateur a mis l'app directement dans Program Files, on scrape sa machine!
  ;Toutefois, sans le /r, c'est sécuritaire car le dossier n'est pas supprimer s'il n'est pas vide
  RMDir "$INSTDIR" 

  ;Suppression au registre des valeurs associées à l'application
  DeleteRegKey /ifempty HKCU "Software\${NOM_APP}"

SectionEnd

;--------------------------------
;Fonction nécessaire pour l'initialisaiton du dialogue de sélection de la langue
Function .onInit
    !insertmacro MUI_LANGDLL_DISPLAY
FunctionEnd