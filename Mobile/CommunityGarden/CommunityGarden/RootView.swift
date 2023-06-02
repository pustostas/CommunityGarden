//
//  RootView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import SwiftUI

struct RootView: View {
    
    
    @ObservedObject private var singleton = Singleton.shared
    @State var isActive = false
    
    
    @ViewBuilder
    func view(root: Singleton.RootRoute) -> some View {

        switch root {
        case .gardens:
            GardensView()
        case .myPlans:
            PlantsView()
        case .gardenMap:
            if let garden = Singleton.shared.currentGarden {
                GardenMapView(map: garden)
            } else {
                Text("Nema Gardena")
            }
                
        default:
            Text("Shoto ne to")
        }
        
    }
    
    var body: some View {
        Text("Pipisk")
            .onAppear{
                isActive = true
            }
        
        NavigationLink(destination: CGView{view(root: singleton.rootRoute)},
                       isActive: $isActive) {
            EmptyView()
        }
        
    }
}

struct RootView_Previews: PreviewProvider {
    static var previews: some View {
        RootView()
    }
}
