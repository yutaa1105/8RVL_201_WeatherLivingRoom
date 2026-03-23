# WeatherLivingRoom — Projet VR

## Description
Expérience de réalité virtuelle immersive dans un appartement connecté 
à la météo de Saguenay en temps réel. La pièce réagit aux conditions 
météorologiques : neige extérieure, ensoleillement et données affichées 
sur la télévision.

## Fonctionnalités
- Météo de Saguenay en temps réel via Open-Meteo API
- Téléportation et Snap Turn
- Bouton TV interactif avec musique spatialisée
- Particules de poussière et de neige

## Déplacements
- Joystick droit : téléportation (viser avec la manette, incliner & relâcher)
- Joystick gauche : Snap Turn
- Déplacement naturel via tracking Quest

## Interactions
- Manette gauche (grip) : interagir avec les objets
- Bouton TV : allume/éteint l'écran & la musique

## Technologies
- Unity 6 / XR Interaction Toolkit 3.3.1
- Meta Quest 3

## Équipe & répartition des rôles
- Candice CARTON : déplacements + interaction avec le bouton de la télé + scène principale
- Nathan WILLAY : API + lumières & particules + son spatialisé + documentation GitHub

## Notes de développement
- Son qui se lance au démarrage : la musique spatialisée de la TV se déclenche automatiquement au lancement de la scène, même lorsque la TV est éteinte.
- Développement sur un seul PC : en raison de conflits de versions Unity, le projet a été développé sur une seule machine avec des pushs alternés entre les membres de l'équipe.
