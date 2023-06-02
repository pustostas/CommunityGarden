//
//  PlantsView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import SwiftUI

struct PlantsView: View {
    @State private var isSidebarOpened = false
    var body: some View {
        ZStack{
        NavigationView{
            VStack{
                Text("Your plants")
            }
        }
        SideBar(isSidebarVisible: $isSidebarOpened,isGardenView: false)
    }
    }
}

struct PlantsView_Previews: PreviewProvider {
    static var previews: some View {
        PlantsView()
    }
}
