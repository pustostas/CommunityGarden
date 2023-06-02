//
//  PlotView.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 02.06.2023.
//

import Foundation
import SwiftUI

struct PlotView: View {
    var plot: Plot
    var owner: User
    
    var offset: CGFloat = 20
    
    var body: some View {
        GeometryReader{ reader in
            ZStack {
                secondaryColor
                    .frame(width: reader.size.width - offset)
                    .frame(height: reader.size.height - offset)
                VStack {
                    Spacer()
                    Text(owner.name)
                    AsyncImage(url: owner.profilePicture) { phase in
                        switch phase {
                        case .empty:
                            ProgressView()
                        case .success(let image):
                            image.resizable()
                                 .aspectRatio(contentMode: .fit)
                                 .frame(maxWidth: 300, maxHeight: 100)
                        case .failure:
                            Image(systemName: "photo")
                        @unknown default:
                            // Since the AsyncImagePhase enum isn't frozen,
                            // we need to add this currently unused fallback
                            // to handle any new cases that might be added
                            // in the future:
                            EmptyView()
                        }
                    }
                    Spacer()
                }
            }
        }
       
    }
}
