Public Class clsMenusNew

    Shared Function BuildMenuListOfChampions() As String
        Dim strMenu As String = ""

        strMenu += MenuItemTop("List Of Champions")

        strMenu += MenuItemSubWithSubs("Baseball")
        strMenu += MenuItemLineItem("State Champions (by Year)", "BAStateChampionships.aspx", False)
        strMenu += MenuItemLineItem("State Champions (by School)", "BAStateChampionsBySchool.aspx", False)
        strMenu += MenuItemSubWithSubsClose("Baseball")

        strMenu += MenuItemSubWithSubs("Basketball")
        strMenu += MenuItemSubWithSubs("Basketball Boys")
        strMenu += MenuItemLineItem("State Champions (by Year)", "BKBStateChampionships.aspx", False)
        strMenu += MenuItemLineItem("State Champions (by School)", "BKBStateChampionsBySchool.aspx", False)
        strMenu += MenuItemSubWithSubsClose("Basketball Boys")

        strMenu += MenuItemSubWithSubs("Basketball Girls")
        strMenu += MenuItemLineItem("State Champions (by Year)", "BKGStateChampionships.aspx", False)
        strMenu += MenuItemLineItem("State Champions (by School)", "BKGStateChampionsBySchool.aspx", False)
        strMenu += MenuItemSubWithSubsClose("Basketball Girls")
        strMenu += MenuItemSubWithSubsClose("Basketball")

        strMenu += MenuItemTopClose("List of Champions")

        Return strMenu
    End Function

    Shared Function BuildMenuIWATG() As String
        Dim strMenu As String = ""

        strMenu += MenuItemTop("List Of Champions")

        strMenu += MenuItemSubWithSubs("Baseball")
        strMenu += MenuItemLineItem("State Champions (by Year)", "BAStateChampionships.aspx", False)
        strMenu += MenuItemLineItem("State Champions (by School)", "BAStateChampionsBySchool.aspx", False)
        strMenu += MenuItemLineItem("# of Tourney Appearances", "BAStateAppearancesCount.aspx", False)
        strMenu += MenuItemLineItem("# of Championships", "BAStateChampionshipCount.aspx", False)
        strMenu += MenuItemLineItem("# of Runners-Up", "BAStateRunnersUpCount.aspx", False)
        strMenu += MenuItemSubWithSubsClose("Baseball")

        strMenu += MenuItemSubWithSubs("Baseball (Fall)")
        strMenu += MenuItemLineItem("State Champions (by Year)", "BAFStateChampionships.aspx", False)
        strMenu += MenuItemLineItem("State Champions (by School)", "BAFStateChampionsBySchool.aspx", False)
        strMenu += MenuItemLineItem("# of Tourney Appearances", "BAStateAppearancesCount.aspx", False)
        strMenu += MenuItemLineItem("# of Championships", "BAFStateChampionshipCount.aspx", False)
        strMenu += MenuItemLineItem("# of Runners-Up", "BAFStateRunnersUpCount.aspx", False)
        strMenu += MenuItemSubWithSubsClose("Baseball")

        strMenu += MenuItemSubWithSubs("Basketball")
        strMenu += MenuItemSubWithSubs("Basketball Boys")
        strMenu += MenuItemLineItem("State Champions (by Year)", "BKBStateChampionships.aspx", False)
        strMenu += MenuItemLineItem("State Champions (by School)", "BKBStateChampionsBySchool.aspx", False)
        strMenu += MenuItemLineItem("# of Championships", "BKBStateChampionshipCount.aspx", False)
        strMenu += MenuItemLineItem("# of Runners-Up", "BKBStateRunnersUpCount.aspx", False)
        strMenu += MenuItemSubWithSubsClose("Basketball Boys")

        strMenu += MenuItemSubWithSubs("Basketball Girls")
        strMenu += MenuItemLineItem("State Champions (by Year)", "BKGStateChampionships.aspx", False)
        strMenu += MenuItemLineItem("State Champions (by School)", "BKGStateChampionsBySchool.aspx", False)
        strMenu += MenuItemLineItem("# of Championships", "BKGStateChampionshipCount.aspx", False)
        strMenu += MenuItemLineItem("# of Runners-Up", "BKGStateRunnersUpCount.aspx", False)
        strMenu += MenuItemSubWithSubsClose("Basketball Girls")
        strMenu += MenuItemSubWithSubsClose("Basketball")

        strMenu += MenuItemTopClose("List of Champions")

        Return strMenu
    End Function

    Shared Function MenuItemTop(strMenuTitle As String) As String
        Dim strMenu As String = ""

        strMenu += "<li class='rd-nav-item'><a class='rd-nav-link' href='#'>" & strMenuTitle & "</a>"
        strMenu += "<ul class='rd-menu rd-navbar-dropdown'>"

        Return strMenu
    End Function
    Shared Function MenuItemTopClose(strMenuTitle As String) As String
        Dim strMenu As String = ""
        strMenu = "</ul></li>"
        Return strMenu
    End Function

    Shared Function MenuItemSubWithSubs(strMenuTitle As String) As String
        Dim strMenuSub As String = ""

        strMenuSub += "<li Class='rd-dropdown-item'><a class='rd-dropdown-link' href='#'>" & strMenuTitle & "</a>"
        strMenuSub += "<ul class='rd-menu rd-navbar-dropdown'>"

        Return strMenuSub
    End Function

    Shared Function MenuItemSubWithSubsClose(strMenuTitle As String) As String
        Dim strMenu As String = ""
        strMenu = "</ul></li>"
        Return strMenu
    End Function

    Shared Function MenuItemLineItem(strMenuTitle As String, strLink As String, ysnBlank As Boolean) As String
        Dim strLineItem As String = ""
        strLineItem = "<li class='rd-dropdown-item'><a class='rd-dropdown-link' href='../" & strLink & "'>" & strMenuTitle & "</a></li>"
        Return strLineItem
    End Function

End Class
