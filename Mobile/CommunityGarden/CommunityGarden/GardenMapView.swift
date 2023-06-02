//
//  GardenMapView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import SwiftUI

struct GardenMapView: View {
    
    var map: Garden
    
    var offset: Float = 2
    
    func getPlotOwner(_ plot: Plot) -> User {
        User(id: "", name: plot.id, firstName: "", secondName: "", birthDate: "", profilePicture: URL(string: "https://i.stack.imgur.com/kpQe2.jpg?s=64&g=1"), email: "", bio: "")
    }
    
    @ViewBuilder
    func createMap(screenSize: CGSize) -> some View {
        ZStack {
            ForEach(map.plots, id: \.id) { plot in
                VStack {
                    Spacer()
                        .frame(height: screenSize.height *  (plot.zeroPoint.y / map.size.height))
                    HStack {
                        Spacer()
                            .frame(width: screenSize.height *  (plot.zeroPoint.x / map.size.height))
                        PlotView(plot: plot, owner: getPlotOwner(plot))
                            .frame(width: screenSize.height *  (plot.size.width / map.size.height))
                            .frame(height: screenSize.height *  (plot.size.height / map.size.height))
                        Spacer()
                    }
                    Spacer()
                }
                .onTapGesture {
                    //TODO: Open plot
                }
            }
        }
    }
    
    var body: some View {
        GeometryReader { reader in
            ScrollView(.horizontal) {
                createMap(screenSize: reader.size)
            }
          
        }
       
    }
}

struct GardenMapView_Previews: PreviewProvider {
    
    
    
    static var gardenMap: Garden {
        
        Garden(id: "",
                  name: "Some",
                  ownerId: "Some",
                  code: "Some",
                  size: .init(width: 40, height: 20),
                  plots: [
                    .init(id: "fa", superviserId: "",
                                zeroPoint: .init(x: 0, y: 0),
                                size: .init(width: 10,
                                            height: 10)),
                    .init(id: "11", superviserId: "",
                                zeroPoint: .init(x: 10, y: 0),
                                size: .init(width: 40,
                                            height: 5)),
                    .init(id: "23", superviserId: "",
                                zeroPoint: .init(x: 10, y: 5),
                                size: .init(width: 5,
                                            height: 10)),
                    .init(id: "123", superviserId: "",
                                zeroPoint: .init(x: 0, y: 10),
                                size: .init(width: 10,
                                            height: 10)),
                  ])
    }
    
    static var previews: some View {
        Group {
            GardenMapView(map:gardenMap)
        }
    }
}

