# AccessibleDirectory
Parfait, voici un **décorticage clair et étape par étape** de ce que tu dois faire pour réussir ce projet. On va suivre la structure du sujet, en séparant les parties obligatoires des bonus, et en gardant les objectifs de sécurité en tête.

---

### 🌐 **I. Création de l'application web en C# (.NET)**

#### Étapes :
1. **Créer un projet web en C# avec .NET** :
   - Utilise ASP.NET MVC ou Razor Pages.
   - Crée une page d’accueil avec :
     - Dernières nouvelles sur Domolia (fictives ou via une API).
     - La météo d’une ville précise (ex : Magnat-l’Étrange, via une API météo comme OpenWeatherMap).

2. **Connexion Active Directory** :
   - Implémente un **login utilisateur** qui utilise les identifiants Active Directory.
   - Tu peux utiliser `System.DirectoryServices` ou une lib comme `LDAP`.

3. **Fonctionnalités une fois connecté** :
   - 🔍 Rechercher un employé via numéro de téléphone ou email (requête LDAP).
   - 📅 Afficher l’agenda (jour/semaine/mois) de l’utilisateur connecté.
   - 📆 Permettre la **création de réunions**, avec des invitations.
   - 🚪 Bouton de **déconnexion**.

#### Sécurité à intégrer obligatoirement :
- ✅ Validation des inputs pour éviter les injections SQL/XSS.
- 🔐 Stocker les mots de passe **hachés** (si tu as besoin de stocker des utilisateurs hors AD).
- 🔑 Mettre en place un **système d'autorisation** selon les rôles des utilisateurs.
- 🔏 Chiffrer les données sensibles des utilisateurs (ex : infos personnelles).

---

### 🖥️ **II. Hébergement de l'application sur Windows (serveur D:)**

#### Étapes :
1. Installer **.NET Framework** et **IIS (Internet Information Services)**.
2. Configurer **IIS** pour héberger ton application :
   - Ajouter un **site web** pointant vers le dossier de ton app.
   - Vérifie que le **poule d’application** est bien configuré.
3. Configurer les **règles de firewall** pour autoriser le trafic HTTP/HTTPS.
4. Déployer ton application (publier en mode release, copier dans IIS).

---

### 🔐 **III. Configuration du serveur OpenSSH sur Windows**

#### Étapes :
1. Installer le **serveur OpenSSH** sur ta VM Windows :
   - Via les “Optional Features” ou PowerShell.
2. Configurer pour accepter les connexions entrantes.
3. Générer une **paire de clés SSH** (public/privée).
4. Ajouter la clé publique dans le fichier `authorized_keys` du serveur.
5. Tester la connexion SSH depuis une autre machine (ou une autre VM).
6. Ouvrir les ports nécessaires dans le **firewall Windows** (par défaut, port 22).

---

### 🎁 **IV. Bonus (si partie obligatoire parfaite)**

Tu peux ajouter ces fonctionnalités **uniquement si tout le reste fonctionne parfaitement** :
- 🛡️ Gestion des permissions par groupe (lecture/écriture).
- 👤 Création de nouveaux utilisateurs (si le compte connecté a le droit).
- 🖥️ Accès à un **bureau distant** (avec navigation de fichiers).
- 💬 Ajout d’une fonctionnalité de **chat interne** entre employés.

---

### 🧾 **V. Soumission**

- Lis le PDF d’aide fourni avec le sujet (VM, verrouillage, soumission).
- **Verrouille** ta VM une fois que tout est terminé.
- Une **snapshot** sera prise pour l’évaluation.
- Rien ne pourra être modifié ensuite, sauf si un évaluateur le demande.

---

### ✅ Checklist finale (avant soumission)

| Tâche | Statut |
|------|--------|
| App en C# créée avec infos Domolia et météo | ☐ |
| Login via Active Directory | ☐ |
| Recherche employé | ☐ |
| Agenda et création de réunion | ☐ |
| Sécurité : validation, hash, chiffrement | ☐ |
| Hébergement sur IIS (port ouvert) | ☐ |
| OpenSSH installé, testé, firewall ok | ☐ |
| Bonus (si tout fonctionne) | ☐ |
| VM verrouillée | ☐ |
