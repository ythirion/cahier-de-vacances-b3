# Firewall Cracker - Backlog

Ce backlog contient les user stories, critères d'acceptation et cas de tests pour l'application Firewall Cracker, une application TRON-themed de validation de mots de passe.

## User Stories

### US-01: En tant qu'utilisateur, je veux entrer un mot de passe pour tenter de briser le firewall
**Priorité**: Haute  
**Description**: L'utilisateur doit pouvoir saisir un mot de passe dans un champ de saisie pour tenter de passer à travers le firewall du système.

**Critères d'acceptation**:
- Un champ de saisie de mot de passe est disponible
- L'interface indique clairement qu'il s'agit d'une tentative de violation de firewall
- Le champ de saisie est facile à identifier et à utiliser

**Cas de test**:
- Vérifier que le champ de saisie du mot de passe est rendu correctement
- Vérifier que le champ de saisie accepte l'entrée de texte

### US-02: En tant qu'utilisateur, je veux recevoir une validation en temps réel de mon mot de passe
**Priorité**: Haute  
**Description**: L'utilisateur doit recevoir un retour immédiat sur la validité de son mot de passe en fonction des critères de sécurité établis.

**Critères d'acceptation**:
- La validation se fait en temps réel pendant la saisie
- Des messages d'erreur spécifiques sont affichés pour chaque critère non respecté
- Une animation d'alarme visuelle apparaît en cas d'échec de validation

**Cas de test**:
- Test: Mot de passe trop court (moins de 8 caractères)
  - Entrée: "Abc123"
  - Résultat attendu: Message d'erreur indiquant une longueur insuffisante
- Test: Mot de passe sans lettre majuscule
  - Entrée: "abc123@#"
  - Résultat attendu: Message d'erreur concernant l'absence de majuscule
- Test: Mot de passe sans lettre minuscule
  - Entrée: "ABC123@#"
  - Résultat attendu: Message d'erreur concernant l'absence de minuscule
- Test: Mot de passe sans chiffre
  - Entrée: "Abcdef@#"
  - Résultat attendu: Message d'erreur concernant l'absence de chiffre
- Test: Mot de passe sans symbole cyber
  - Entrée: "Abcdef123"
  - Résultat attendu: Message d'erreur concernant l'absence de symbole cyber
- Test: Mot de passe avec caractères non autorisés
  - Entrée: "Abc123!^"
  - Résultat attendu: Message d'erreur concernant des caractères non autorisés

### US-03: En tant qu'utilisateur, je veux savoir quels critères de sécurité mon mot de passe doit respecter
**Priorité**: Moyenne  
**Description**: L'utilisateur doit connaître les exigences spécifiques pour qu'un mot de passe soit accepté par le système.

**Critères d'acceptation**:
- Les critères de validation sont clairement communiqués à l'utilisateur:
  - Minimum 8 caractères
  - Au moins une lettre majuscule
  - Au moins une lettre minuscule
  - Au moins un chiffre
  - Au moins un cyber-symbole (. * # @ $ % &)
  - Uniquement des caractères alphanumériques et les symboles spécifiés

**Cas de test**:
- Vérifier que tous les critères de mot de passe sont affichés à l'utilisateur
- Vérifier que les critères sont clairement lisibles et compréhensibles

### US-04: En tant qu'utilisateur, je veux recevoir une confirmation visuelle lorsque j'ai réussi à briser le firewall
**Priorité**: Moyenne  
**Description**: Lorsque l'utilisateur saisit un mot de passe valide, il doit recevoir une confirmation visuelle réussie et immersive.

**Critères d'acceptation**:
- Un message de succès "Firewall Breached" ou "System Access Granted" est affiché
- Une animation de succès est déclenchée
- L'interface change d'état pour indiquer que l'accès est accordé

**Cas de test**:
- Test: Mot de passe valide
  - Entrée: "Abc123@#"
  - Résultat attendu: Message de succès et animation correspondante

### US-05: En tant qu'utilisateur avec des besoins d'accessibilité, je veux pouvoir utiliser l'application selon les normes RGAA
**Priorité**: Haute  
**Description**: L'application doit être accessible à tous les utilisateurs, y compris ceux qui utilisent des technologies d'assistance, conformément au Référentiel Général d'Amélioration de l'Accessibilité (RGAA).

**Critères d'acceptation**:
- Tous les éléments interactifs sont utilisables au clavier
- Le champ de saisie est correctement étiqueté avec un label approprié
- Les contrastes de couleurs respectent les normes d'accessibilité (4.5:1 minimum)
- Les animations peuvent être désactivées pour les utilisateurs sensibles aux mouvements
- Les messages d'erreur et de succès sont annoncés aux lecteurs d'écran
- L'application est navigable et compréhensible avec un lecteur d'écran
- La structure sémantique HTML est correcte et logique

**Cas de test**:
- Test: Navigation au clavier
  - Action: Naviguer dans l'application en utilisant uniquement le clavier (Tab, Shift+Tab, Enter)
  - Résultat attendu: Tous les éléments interactifs sont accessibles et utilisables
- Test: Contraste des couleurs
  - Action: Vérifier les contrastes entre le texte et l'arrière-plan avec un outil d'analyse de contraste
  - Résultat attendu: Tous les contrastes respectent le minimum de 4.5:1 (ou 3:1 pour les grands textes)
- Test: Lecteur d'écran
  - Action: Parcourir l'application avec un lecteur d'écran (VoiceOver, NVDA, JAWS)
  - Résultat attendu: Tous les contenus et messages sont correctement annoncés
- Test: Désactivation des animations
  - Action: Utiliser le paramètre "prefers-reduced-motion" du navigateur
  - Résultat attendu: Les animations sont réduites ou désactivées

